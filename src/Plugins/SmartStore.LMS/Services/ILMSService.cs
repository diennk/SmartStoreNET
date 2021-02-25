using SmartStore.LMS.Domain;

namespace SmartStore.LMS.Services
{
    public partial interface ILMSService
    {
        LMSRecord GetLMSRecord(int entityId, string entityName);
        LMSRecord GetLMSRecordById(int id);
        void InsertLMSRecord(LMSRecord record);
        void UpdateLMSRecord(LMSRecord record);
        void DeleteLMSRecord(LMSRecord record);
    }
}
