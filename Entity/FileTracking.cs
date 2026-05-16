namespace AmexParser;
public class FileTracking
{
    public string FileHeader {get;set;}     //ORGANIZATION - EXTERNAL FILE TRACKING
    public string FileType {get;set;}   //Outclear / Inclear Files
    public string ProcessorId {get;set;}
    public string SequenceNumber {get;set;}
    public string ClaimDate {get;set;}
    public string Status {get;set;} //Complete / Rejected / In Process
    public int TransactionCount {get;set;}

}

/*
File Header | File Type | Processor Id | Sequence Number | Claim Date | Status | Transaction count |

*/