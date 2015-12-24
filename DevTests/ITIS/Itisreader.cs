using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITIS
{
    public class SearchResult
    {
        public string QueryName { get; set; }
        public string QueryLanguage { get; set; }
        public List<SearchResultItem> Results { get; set; }

        public int ResultsCount
        {
            get
            {
                if (this.Results == null)
                {
                    return 0;
                }
                return this.Results.Count;
            }
        }
    }

    public class SearchResultItem
    {   //The id
        public int TSN { get; set; }
        
        public string CompleteName { get; set; }
        
        public string RankName { get; set; }
        
        public string EnglishName { get; set; }
        
        public string VernacularName { get; set; }
        
        public string Language { get; set; }

    }
    public static class ITISReader
    {
        /// <summary>
        /// on a l nom anglais, pas spécialement le francais > si langue <> anglais > voir dans les vernaculars ou alors dans les autres
        /// </summary>
        /// <param name="name"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public static SearchResult SearchAnimal(string name, string language)
        {
            SearchResult result = new SearchResult { QueryName = name, QueryLanguage = language };
            name = name.Replace(' ', '%');
            //set @name = replace(@name,' ','%')
            string query = @"
            select 
            t.tsn TSN
            ,tut.rank_name RankName
            ,t.complete_name CompleteName
            ,v.vernacular_name VernacularName
            ,v.language Language
            ,ve.vernacular_name EnglishName
            FROM [taxonomic_units] t
            inner join kingdoms k 
	            on  k.kingdom_id=t.kingdom_id
	            and k.kingdom_id = 5 -- animal
            inner join [taxon_unit_types] tut
                on  tut.kingdom_id =t.kingdom_id 
                and tut.rank_id = t.rank_id 
            left join [vernaculars] v -- translated name
	            on  v.tsn=t.tsn
            inner join [vernaculars] ve -- english name
	            on  ve.tsn=t.tsn
	            and ve.language='English'

            where t.rank_id >= 220 -- species and subspecies and .. 
            and (t.complete_name like '%'+@name+'%'
            or (v.vernacular_name like '%'+@name+'%' and  v.language=@language))";


            using (ITISContext ctx = new ITISContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                ctx.Configuration.ProxyCreationEnabled = false;
                ctx.Database.Log = Log;
                var res = ctx.Database.SqlQuery<SearchResultItem>(query,
                    new SqlParameter("name", name),
                    new SqlParameter("language", language));
                result.Results = res.ToList();
            }

            return result;
        }

        public static void Log(string message)
        {
            Console.WriteLine(message);
            Debug.WriteLine(message);
        }

        public static SearchResult SearchAnimal_ADO(string name, string language)
        {
            SearchResult result = new SearchResult { QueryName = name, QueryLanguage = language, Results = new List<SearchResultItem>() };
            name = name.Replace(' ', '%');
        
            string query = @"
            select 
            t.tsn TSN
            ,tut.rank_name RankName
            ,t.complete_name CompleteName
            ,v.vernacular_name VernacularName
            ,v.language Language
            ,ve.vernacular_name EnglishName
            FROM [taxonomic_units] t
            inner join kingdoms k 
	            on  k.kingdom_id=t.kingdom_id
	            and k.kingdom_id = 5 -- animal
            inner join [taxon_unit_types] tut
                on  tut.kingdom_id =t.kingdom_id 
                and tut.rank_id = t.rank_id 
            left join [vernaculars] v -- translated name
	            on  v.tsn=t.tsn
            inner join [vernaculars] ve -- english name
	            on  ve.tsn=t.tsn
	            and ve.language='English'

            where t.rank_id >= 220 -- species and subspecies and .. 
            and (t.complete_name like '%'+@name+'%'
            or (v.vernacular_name like '%'+@name+'%' and  v.language=@language))";


            using (SqlConnection sqlCon = new SqlConnection("data source=(local);initial catalog=itisMSSqlTest;integrated security=True"))
            {
                using (SqlCommand com = sqlCon.CreateCommand())
                {
                    com.CommandText = query;
                    com.Parameters.Add(new SqlParameter("name", name));
                    com.Parameters.Add(new SqlParameter("language", language));
                    sqlCon.Open();
                    SqlDataReader reader = com.ExecuteReader();
                    while(reader.Read())
                    {
                        SearchResultItem item = new SearchResultItem
                        {
                            TSN = reader.GetInt32(0),
                            RankName = reader.GetString(1),
                            CompleteName = reader.GetString(2),
                            VernacularName = reader.GetString(3),
                            Language = reader.GetString(4),
                            EnglishName = reader.GetString(5)
                        };
                        result.Results.Add(item);
                    }

                }
            }

            return result;
        }
    }
}
