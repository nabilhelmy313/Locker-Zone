namespace LockerZone.Domain.Dtos
{
    public class AttachmentDto
    {
        public Guid Id { get; set; }
        public string TableName { get; set; } = string.Empty;
        public string RowId { get; set; }= string.Empty;
        public string FileTypeCode { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string MIMEType { get; set; } = string.Empty;
        public long FileLength { get; set; }    
        public string FileExtension { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
    }
}
