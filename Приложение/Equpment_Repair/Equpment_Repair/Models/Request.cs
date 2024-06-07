using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Equpment_Repair
{
    public partial class Request
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime? AddictionDate { get; set; }
        public string Equpment { get; set; }
        public string MalfunctionType { get; set; }
        public string ProblemDescription { get; set; }
        public int ClientId { get; set; }
        public int? EmployeeId { get; set; }
        public int? RequestTypeId { get; set; }
        public int? CompletionStageId { get; set; }

        public virtual User Client { get; set; }
        public virtual CompletionStage CompletionStage { get; set; }
        public virtual User Employee { get; set; }
        public virtual RequestType RequestType { get; set; }
    }
}
