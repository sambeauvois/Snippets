    /// <summary>
    /// Summary description for CodeReport
    /// </summary>
   // [TestClass]
    public class CodeReport
    {
        public CodeReport()
        {

        }

        public class ClassInfo
        {
            public string Name { get; set; }
            public string FullName { get; set; }
            public string File { get; set; }
            public string Namespace { get; set; }
        }

        public string rowseparatorTemplate = "<tr><th  colspan=\"4\"><hr/></th></tr>";
        public string rowClassTemplate = "<tr><th style=\"text-align:left;\" colspan=\"4\"><h4>{0}</h4></th></tr>";
        public string rowMethodTemplate = "<tr><td>&nbsp;&nbsp;{0}</td><td>{1}</td><td style=\"font-weight:bold;\">{2}</td><td>{3}</td></tr>";

        /// <summary>
        /// liste les différentes methodes des services
        /// </summary>
        //[TestMethod]
        public void GenerateCodeReport()
        {

            List<ClassInfo> classes = new List<ClassInfo>();

            int count = 0;
            StringBuilder builder = new StringBuilder(@"<html><head><title>report</title></head><body>");
            Assembly mscorlib = typeof(ClientService).Assembly;//ClientService is a class from the target assembly
            builder.Append("<h1>[[TITLE]]</h1><table>");

            foreach (Type type in mscorlib.GetTypes())
            {
                builder.AppendLine(rowseparatorTemplate);

                classes.Add(new ClassInfo
                {
                    Name = type.Name,
                    FullName = type.FullName,
                    Namespace = type.Namespace,
                });

                if (type.BaseType == typeof(BaseService))// test for specific types
                {
                    builder.AppendLine(string.Format(rowClassTemplate, "Some title"));
                }
           
                builder.AppendLine(string.Format(rowClassTemplate, type.Name));


                MethodInfo[] methods = type.GetMethods();
                foreach (var method in methods)
                {
                    var parameters = string.Join(",", (from ParameterInfo p in method.GetParameters()
                                                       select string.Format("<strong>{0}</strong> ({1})", p.Name, p.ParameterType)));

                    string returnType = method.ReturnType.Name;
                   
                    if(method.ReturnType.IsGenericType)
                    {
                      returnType += string.Join(",", (from arg in method.ReturnType.GenericTypeArguments
                                                      select string.Format("<strong>{0}</strong> ",arg.Name)));
                    }

                    builder.AppendLine(string.Format(rowMethodTemplate, method.IsPublic ? "public" : "", returnType, method.Name, parameters));
                }

                ++count;
            }

            builder.Replace("[[TITLE]]", string.Format("nb classes :{0}", count));

            builder.Append("</table></body></html>");

            File.WriteAllText("methodsreport.html", builder.ToString());

            // MethodInfo[] methods = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).SelectMany(x => x.GetMethods().Where(y => y.IsPublic)).ToArray();
        }

    }
