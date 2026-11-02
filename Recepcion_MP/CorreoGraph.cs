using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace Recepcion_MP
{
    /// <summary>
    /// Envio de correo por Microsoft Graph (Office 365) con la app Entra de Recepcion_MP.
    /// Reemplaza al SMTP de mail1.mrlucky.com.mx (ya no existe). Recibe el mismo MailMessage.
    /// El secreto esta en CorreoGraphSecreto.cs (no se sube a git, ver .gitignore).
    /// </summary>
    public static partial class CorreoGraph
    {
        const string TenantId = "d20460dd-675d-4b51-87cc-9d10f9175633";
        const string ClientId = "c982ac22-b59a-441c-905a-9eb273ade26b";
        const string Dominio = "@mrlucky.com.mx";
        // Si el remitente no es de mrlucky.com.mx (p. ej. funtanet@grupou.mx) se envia desde este buzon
        const string RemitentePorDefecto = "sistemas@mrlucky.com.mx";

        static string _token;
        static DateTime _tokenExpira = DateTime.MinValue;

        public static void Enviar(MailMessage mensaje)
        {
            // .NET 4.0 no trae el enum Tls12; 3072 = TLS 1.2 (requiere .NET 4.5+ instalado en la PC)
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            string buzon = mensaje.From != null ? mensaje.From.Address : "";
            if (!buzon.EndsWith(Dominio, StringComparison.OrdinalIgnoreCase))
                buzon = RemitentePorDefecto;

            // Sin "from" en el mensaje: Graph usa el buzon remitente (con un from distinto el correo se filtra)
            StringBuilder json = new StringBuilder();
            json.Append("{\"message\":{");
            json.Append("\"subject\":").Append(Texto(mensaje.Subject)).Append(',');
            json.Append("\"body\":{\"contentType\":\"").Append(mensaje.IsBodyHtml ? "HTML" : "Text")
                .Append("\",\"content\":").Append(Texto(mensaje.Body)).Append("},");
            json.Append("\"toRecipients\":").Append(Lista(mensaje.To));
            if (mensaje.CC.Count > 0) json.Append(",\"ccRecipients\":").Append(Lista(mensaje.CC));
            if (mensaje.Bcc.Count > 0) json.Append(",\"bccRecipients\":").Append(Lista(mensaje.Bcc));
            if (mensaje.Attachments.Count > 0)
            {
                json.Append(",\"attachments\":[");
                for (int i = 0; i < mensaje.Attachments.Count; i++)
                {
                    Attachment a = mensaje.Attachments[i];
                    MemoryStream ms = new MemoryStream();
                    if (a.ContentStream.CanSeek) a.ContentStream.Position = 0;
                    a.ContentStream.CopyTo(ms);
                    if (i > 0) json.Append(',');
                    json.Append("{\"@odata.type\":\"#microsoft.graph.fileAttachment\",\"name\":").Append(Texto(a.Name))
                        .Append(",\"contentBytes\":\"").Append(Convert.ToBase64String(ms.ToArray())).Append("\"}");
                }
                json.Append(']');
            }
            json.Append("},\"saveToSentItems\":true}");

            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + Token();
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                try
                {
                    wc.UploadString("https://graph.microsoft.com/v1.0/users/" + Uri.EscapeDataString(buzon) + "/sendMail", json.ToString());
                }
                catch (WebException ex)
                {
                    if (ex.Response == null) throw;
                    using (StreamReader r = new StreamReader(ex.Response.GetResponseStream()))
                        throw new InvalidOperationException("Graph sendMail fallo: " + r.ReadToEnd(), ex);
                }
            }
        }

        static string Token()
        {
            if (_token != null && DateTime.UtcNow < _tokenExpira) return _token;
            string datos = "client_id=" + Uri.EscapeDataString(ClientId)
                         + "&client_secret=" + Uri.EscapeDataString(Secreto)
                         + "&scope=" + Uri.EscapeDataString("https://graph.microsoft.com/.default")
                         + "&grant_type=client_credentials";
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string resp = wc.UploadString("https://login.microsoftonline.com/" + TenantId + "/oauth2/v2.0/token", datos);
                _token = Regex.Match(resp, "\"access_token\"\\s*:\\s*\"([^\"]+)\"").Groups[1].Value;
                Match exp = Regex.Match(resp, "\"expires_in\"\\s*:\\s*\"?(\\d+)");
                _tokenExpira = DateTime.UtcNow.AddSeconds((exp.Success ? int.Parse(exp.Groups[1].Value) : 3600) - 300);
                return _token;
            }
        }

        static string Lista(MailAddressCollection direcciones)
        {
            StringBuilder sb = new StringBuilder("[");
            for (int i = 0; i < direcciones.Count; i++)
            {
                if (i > 0) sb.Append(',');
                sb.Append("{\"emailAddress\":{\"address\":").Append(Texto(direcciones[i].Address)).Append("}}");
            }
            return sb.Append(']').ToString();
        }

        static string Texto(string s)
        {
            if (s == null) return "\"\"";
            StringBuilder sb = new StringBuilder("\"");
            foreach (char c in s)
            {
                switch (c)
                {
                    case '"': sb.Append("\\\""); break;
                    case '\\': sb.Append("\\\\"); break;
                    case '\n': sb.Append("\\n"); break;
                    case '\r': sb.Append("\\r"); break;
                    case '\t': sb.Append("\\t"); break;
                    default:
                        if (c < 0x20) sb.Append("\\u").Append(((int)c).ToString("x4"));
                        else sb.Append(c);
                        break;
                }
            }
            return sb.Append('"').ToString();
        }
    }
}
