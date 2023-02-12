var folderGroups = new Dictionary<string, string[]>
{
    { "code", new string[] {"cs", "csproj" } },
    { "design", new string[] { "drawio", "pdn" } },
    { "docs", new string[] { "pdf", "docx", "ppt", "pptx" } },
    { "notes", new string[] { "txt"}},
    { "images", new string[] {"png", "jpeg", "jpg" } },
    { "crypto", new string[] {"kdbx" } }
};


var folderPath = @"C:\Users\Ognjen\Desktop\Test";

var files = Directory.EnumerateFiles(folderPath, "*.*", SearchOption.AllDirectories);

var dict = files.GroupBy(f => f.Split('.').Last()).ToDictionary(gr => gr.Key, gr => gr.ToList());


foreach(var group in folderGroups) 
{
    var fls = dict.Where(de => group.Value.Contains(de.Key)).SelectMany(wf => wf.Value).ToList();

   
    var dir = Directory.CreateDirectory(Path.Combine(folderPath, group.Key));

    foreach(var ftm in fls)
    {
        var name = Path.GetFileName(ftm);

        File.Move(ftm, Path.Combine(folderPath, group.Key, name));
    }
}
