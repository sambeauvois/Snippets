 HtmlMailBuilder mailBuilder = new HtmlMailBuilder();

            mailBuilder.AppendTitle("Super test");
            mailBuilder.AppendTable((col) =>
            {
                col.AppendRow("va", "cc");
                col.AppendRow("va", "cc");
                col.AppendRow("va", "cc");
            }, "col1", "col2");
            mailBuilder.AppendHorizontalLine();
            mailBuilder.AppendTitle(2, "titre2");

            mailBuilder.AppendTable((col) =>
           {
               for (int i = 0; i < 15; i++)
               {
                   col.AppendRow("titre" + i, "valeur " + i);
               }
           }, "titre", "valeur");
