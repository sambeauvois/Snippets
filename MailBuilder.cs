 public class MailBuilder 
    {
        protected StringBuilder Builder { get; set; }
        public MailBuilder()
        {
            Builder = new StringBuilder();
        }
        public override string ToString()
        {
            return Builder.ToString();
        }
    }
    
    
        public class HtmlMailBuilder : MailBuilder
    {
        public void AppendTable(Func<string> addRows, params string[] args)
        {
            Builder.AppendLine("<table>");
            Builder.AppendLine("<thead>");
            Builder.AppendLine("<tr>");
            foreach (var arg in args)
            {
                Builder.AppendFormat("<th>{0}</th>", arg);
                Builder.AppendLine();
            }
            Builder.AppendLine("</tr>");
            Builder.AppendLine("</thead>");
            Builder.AppendLine("<tbody>");

            Builder.Append(addRows());

            Builder.AppendLine("</tbody>");
            Builder.AppendLine("</table>");
        }

        public void AppendTable(Action<HtmlMailBuilder> addRows, string classname = "", params string[] args)
        {
            Builder.AppendLine("<table class=\"" + classname + "\">");
            Builder.AppendLine("<thead>");
            Builder.AppendLine("<tr>");
            foreach (var arg in args)
            {
                Builder.AppendFormat("<th>{0}</th>", arg);
                Builder.AppendLine();
            }
            Builder.AppendLine("</tr>");
            Builder.AppendLine("</thead>");
            Builder.AppendLine("<tbody>");

            addRows(this);

            Builder.AppendLine("</tbody>");
            Builder.AppendLine("</table>");
        }

        public void AppendRow(string classname = "", params string[] args)
        {

            Builder.AppendLine("<tr class=\"" + classname + "\">");
            foreach (var arg in args)
            {
                Builder.AppendFormat("<td>{0}</td>", arg);
                Builder.AppendLine();
            }
            Builder.AppendLine("</tr>");
        }

        public void AppendTitle(string content)
        {
            Builder.AppendLine(string.Format("<h1>{0}</h1>", content));
        }
        public void AppendTitle(int titleLevel, string content)
        {
            if (titleLevel < 1)
            {
                titleLevel = 1;
            }
            if (titleLevel > 6)
            {
                titleLevel = 6;
            }
            Builder.AppendLine(string.Format("<h{0}>{1}</h{0}>", titleLevel, content));
        }

        public void AppendBreak()
        {
            Builder.AppendLine("<br/>");
        }

        public void AppendHorizontalLine()
        {
            Builder.AppendLine("<hr/>");
        }

        public void AppendParagraph(string content)
        {
            Builder.AppendLine("<p>");
            Builder.AppendLine(content);
            Builder.AppendLine("</p>");
        }
    }
