namespace AmexParser;
public class FieldPosition
{
    public string? ReportType {get;set;} //fileinfo, filetracking, nostro, issuer settlement, acuirer settlement
    public string? FieldType {get;set;} //name of the field
    public int StartPosition{get;set;}  // start position of the field
    public int EndPosition {get;set;}   //end position of the field


    
}

