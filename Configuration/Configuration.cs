namespace AmexParser;
public class Configuration
{
    public static string FilePath = @"C:\Users\AmritS\Downloads\dar";
    
    public  int BusinessDateStart {get;} = 15;
    public  int BusinessDateLength {get;} = 10;
    public  int ProcessingDateStart {get;} = 122;
    public  int ProcessingDateLength {get;} = 10;
    public string FileTrackingHeader {get;} = "ORGANIZATION - EXTERNAL FILE TRACKING";
    public string NostroHeader {get;} = "ORGANIZATION - NET SETTLEMENT SUMMARY";
    public string IssuerSettlementHeader {get;} = "ISSUER - GROSS SETTLEMENT SUMMARY";
    public string AcquirerSettlementHeader {get;} = "ACQUIRER - GROSS SETTLEMENT SUMMARY";
    public int SettlementCurrencyStart {get;} = 26;
    public int SettlementCurrencyLength {get;} = 3;

    public int FileTypeStart {get;} = 0;
    public int FileTypeLength {get;} = 14;
    public int ProcessIdStart {get;} = 14;
    public int ProcessIdLength {get;} = 11;
    public int SequenceStart {get;} = 28;
    public int SequenceLength {get;} = 7;
    public int ClaimDateStart {get;} = 44;
    public int ClaimDateLength {get;} = 7;
    public int StatusStart {get;} = 67;
    public int StatusLength {get;} = 13;
    public int TransactionCountStart {get;} = 97;
    public int TransactionCountLength {get;} = 11;




}
/*
TOTAL GROSS SETTLEMENT                                       194,149.17CR                                                                                                                                                                                               
TOTAL PASS THROUGH FEES                                            0.00                                                                                                                 
TOTAL NETWORK FEES                                                 0.00                                                             
TOTAL ISSUER'S/NETWORK RATE AMOUNT                             2,912.23                                                             
TOTAL NET SETTLEMENT                                         191,236.94CR                                                           
SETTLEMENT CURRENCY CODE: 840 USD                                                                                                   
TOTAL GROSS SETTLEMENT                                        35,578.46CR                                                                                                                                                                                              
TOTAL PASS THROUGH FEES                                            0.00                                                                                                                                                                                                 
TOTAL NETWORK FEES                                                 0.00                                                                                                                                                                                                
TOTAL ISSUER'S/NETWORK RATE AMOUNT                               529.51                                                                                                                                                                                                
TOTAL NET SETTLEMENT                                          35,048.95CR   



POS                                                                                                                                                                                                                                                                    
                       PRES                                                 OUTCLEAR                INCLEAR                         
                       CURR  TRANSACTION        PRESENTMENT                    GROSS                  GROSS                    NET  
                       CODE        COUNT             AMOUNT               SETTLEMENT             SETTLEMENT             DIFFERENCE                                                                                                                                      
DEBIT                                                                                                                                                                                                                                                                   
 1ST PRESENTMENT        356            3          10,176.00                     0.00              10,176.00              10,176.00  
                        524           19         317,000.25               198,125.17CR                 0.00             198,125.17CR                                                                                                                                   
CREDIT                                                                                                                                                                                                                                                                  
 1ST PRESENTMENT        356            1           6,200.00                     0.00               6,200.00CR             6,200.00CR                                                                                                                                   
TOTAL FOR POS                         23                                  198,125.17CR             3,976.00             194,149.17CR                                                                                                                                    
TOTAL FOR SETTLEMENT CURRENCY CODE: 356 INR                               198,125.17CR             3,976.00             194,149.17CR
*/