using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Checkmarx.DataTypes;
using RestSharp;
using Newtonsoft.Json;
using Checkmarx.CxDAL;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex reg = new Regex(@"(?i)(http|https):\/\/.*:(?<Password>.*?)@.*\/");

            var mat = reg.Match(@"https://checkmarxQA:cx123456@github.com//checkmarxQA/qa.git");

            string pass = mat.Groups["Password"].Value;

            if (reg.IsMatch(@"https://checkmarxQA:cx123456@github.com//checkmarxQA/qa.git"))
            {
                string[] bla = reg.GetGroupNames();
                string[] afve = Regex.Split(@"https://checkmarxQA:cx123456@github.com//checkmarxQA/qa.git", @"(?i)(http|https):\/\/.*:.*@.*\/");
            }

            string[] argweg = reg.Split(@"https://checkmarxQA:cx123456@github.com//checkmarxQA/qa.git");

            RestClient restClient = new RestClient(@"https://api.github.com");

            ITeamsDataProvider provider = new TeamsDataProvider();

            Guid[] guids = new Guid[3] { new Guid(), new Guid(), new Guid() };

            provider.GetTeamsWithParentOfType(guids, TeamType.Server);

            var req = new RestRequest(@"/repos/{owner}/{repos}/commits")
            {
                Method = Method.GET,
                RequestFormat = DataFormat.Json,
            };

            req.AddHeader("Accept", "application/vnd.github.v3+json");
            req.AddParameter("owner", "OWASP", ParameterType.UrlSegment);
            req.AddParameter("repos", "DevGuide", ParameterType.UrlSegment);
            //req.AddParameter("branch", branch, ParameterType.UrlSegment);

             IRestResponse response = restClient.Execute(req);

            var result = JsonConvert.DeserializeObject<ICollection<Commit>>(response.Content);



            Uri sa = new Uri(@"https://na31.salesforce.com/_ui/identity/oauth/ui/AuthorizationPage");


            string url = "https://github.com/cxehud/test/";


            ProjectGITSetting settings = new ProjectGITSetting();

            settings.Url = url;

            settings.GitHubSettings = new ProjectGITSetting.ProjectGitHubIntegrationSettings();

            settings.GitHubSettings.Username = "cxehud";
            settings.GitHubSettings.Password = "Zaqxswcde1";

            string se = ProjectGITSetting.SourceRepositorySettings2String(settings);


            Uri uri = new Uri(url);

            string[] segments = uri.AbsolutePath.Split('/').Where(segment => !string.IsNullOrEmpty(segment)).ToArray();

            string s = Console.ReadLine();

            string a = Console.ReadLine();
            string k = Console.ReadLine();

            string d = s;

            string b = d;

            string sql = "select * from v where a = " + b;
            OleDbCommand c = new OleDbCommand(sql);

            sql = "select * from v where a = " + k;
            OleDbCommand c2 = new OleDbCommand(sql);

            OleDbDataAdapter adapter = new OleDbDataAdapter();

            adapter.SelectCommand = c;

            adapter.Fill(new System.Data.DataSet());


            adapter.Fill(new System.Data.DataSet());
        }

        public class Commit
        {
            public string sha { get; set; }
            public string html_url { get; set; }
            public internalcommit commit { get; set; }
            public Committer committer { get; set; }
        }

        public class Committer
        {
            public string login { get; set; }
            
        }

        public class internalcommit
        {
            public committerr committer { get; set; }
            public class committerr
            {
                public DateTime date { get; set; }
            }
        }
    }
}
