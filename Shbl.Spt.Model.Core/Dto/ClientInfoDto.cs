namespace Shbl.Spt.Model.Core.Dto
{
    public class ClientInfoDto
    {
        public int CfTypeId { get; set; }
        public string CfTypeName { get; set; }
        public int? ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string ActivityTitle { get; set; }
        public string ActivityDesc { get; set; }
        public byte? Session { get; set; }
        public int? QuestionId { get; set; }
        public bool? IsTest { get; set; }
        public bool IsAdmin { get; set; }
    }
}