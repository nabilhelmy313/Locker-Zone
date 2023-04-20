namespace LockerZone.Domain.Entities
{
    public class Attachment:BaseEntity
    {
        public string Table_Name { get; set; } = string.Empty;
        public string Row_Id { get; set; }= string.Empty;
        public string File_Type_Code { get; set; } = string.Empty;
        public string File_Name { get; set; } = string.Empty;
        public string MIME_Type { get; set; } = string.Empty;
        public long File_Length { get; set; }
        public string File_Extension { get; set; } = string.Empty;
        public string File_Path { get; set; } = string.Empty;
    }
}
