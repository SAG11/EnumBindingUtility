 namespace EnumBindingUtitlity
{
    public interface IBindEnum{
        public string FileAccessPath { get; set; } 
        public string SearchPattern{get;set;}    
        public string DestinationFilePath { get; set; } 
        
        public void BindEnumToModel();
    }
}