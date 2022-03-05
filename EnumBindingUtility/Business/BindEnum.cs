 namespace EnumBindingUtitlity
{
    public class BindEnum : IBindEnum
    {
        #region ===Properties===
        public string FileAccessPath { get; set; } 
        public string SearchPattern{get;set;}    
        public string DestinationFilePath { get; set; } 
        #endregion

        public void BindEnumToModel()
        {
            if(string.IsNullOrEmpty(FileAccessPath))
            { 
                Console.WriteLine("Please Provide File Access Path. The Provided File Path Is Null Or Empty.");
                return;
            }
            
            DirectoryInfo dirInfo = new DirectoryInfo(FileAccessPath);
            FileInfo[] fileNames = dirInfo.GetFiles();
            // string[] fileNames = Directory.GetFiles(FileAccessPath,SearchPattern);

            if(fileNames is null || fileNames.Count() <= 0)
            {
                Console.WriteLine("No Files Found In Given File Path.");
                return;
            }

            foreach(var fileName in fileNames)
            {
                var fileContent = File.ReadAllLines(fileName.FullName);
                List<string> ovFileContent = new List<string>();

                foreach(var content in fileContent)
                {
                   string newContent = content;
                   var splitProperty = content.Trim().Split(' ');

                    if(splitProperty.Count() >= 2)
                    {
                    if(splitProperty[1].Contains("short",StringComparison.InvariantCultureIgnoreCase)
                    && splitProperty[2].Contains("_Enum",StringComparison.InvariantCultureIgnoreCase))
                    {
                        string enumToBind  = splitProperty[2].Replace("_Enum","Ind");
                        newContent = content.Replace("short",enumToBind);
                        ovFileContent.Add(newContent);
                        continue;
                    }
                    }
                   ovFileContent.Add(newContent);
                }
                   File.WriteAllLines(fileName.FullName,ovFileContent.ToArray());

            }

        }
    }
}