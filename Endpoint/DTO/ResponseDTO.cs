namespace StreamingService.DTO;

public class ResponseDTO
{
    public string FileName { get; set; }
    public string Message { get; set; }

    public ResponseDTO(string fileName,  string message)
    {
        FileName = fileName;
        Message = message;
    }
}