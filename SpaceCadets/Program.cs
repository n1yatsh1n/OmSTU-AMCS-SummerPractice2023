using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SpaceCadets;
public class Cadet{
    public string Name { get; set; } = "";
        public string Group { get; set; } = "";
        public string Discipline { get; set; } = "";
        public double Mark { get; set; } = 0;
}

public class Program
{
    public static void Main(string[] arguments)
    {
        dynamic jsonInputFile = JsonConvert.DeserializeObject(File.ReadAllText(arguments[0])) ?? new JObject();
        List<Cadet> cadets = jsonInputFile.data.ToObject<List<Cadet>>();
        List<dynamic> results = new List<dynamic>();

        switch (jsonInputFile.taskName){
            case "GetStudentsWithHighestGPA":
            {
                results = GetStudentsWithHighestGPA(cadets);
                break;
            }
            case "CalculateGPAByDiscipline":
            {
                results = CalculateGPAByDiscipline(cadets);
                break;
            }
            case "GetBestGroupsByDiscipline":
            {
                results = GetBestGroupsByDiscipline(cadets);
                break;
            }
        }
        string otputFile = JsonConvert.SerializeObject(new { Response = results }, Formatting.Indented);
        File.WriteAllText(arguments[1], otputFile);
    }

    public static List<dynamic> GetStudentsWithHighestGPA(List<Cadet> cadets)
    {
         double highestGPA = cadets.Max(cadet => cadet.Mark);
            var result = cadets.Where(cadet => cadet.Mark == highestGPA).Select(cadet => new { Name = cadet.Name, Mark = Math.Round(cadet.Mark, 2) });

            return result.ToList<dynamic>();
    }

     public static List<dynamic> CalculateGPAByDiscipline(List<Cadet> cadets)
    {
       var result = cadets.GroupBy(cadet => cadet.Discipline).Select(group => new {
            Discipline = group.Key,
            Mark = Math.Round(group.Average(cadet => cadet.Mark), 2)
        }).ToDictionary(item => item.Discipline, item => item.Mark);

    List<dynamic> resultList = result.Select(item => new { Discipline = item.Key, Mark = item.Value }).ToList<dynamic>();
    return resultList;
    }

    public static List<dynamic> GetBestGroupsByDiscipline(List<Cadet> cadets)
    {
        var groupsWithAllMarks = cadets
        .GroupBy(cadet => new { cadet.Discipline, cadet.Group })
        .Select(group => new
        {
            Discipline = group.Key.Discipline,
            Group = group.Key.Group,
            Mark = group.Average(cadet => cadet.Mark)
        }).GroupBy(cadet => cadet.Discipline).Select(g => new
        {
            Discipline = g.Key,
            Group = g.OrderByDescending(cadet => cadet.Mark).First().Group,
            GPA = g.Max(cadet => cadet.Mark)
        }).ToList<dynamic>();

        return groupsWithAllMarks;
    }
}
