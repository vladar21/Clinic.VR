using System;

namespace Clinic.VR
{
    public class ReceiptTime
    {
        public int ReceiptTimeID { get; set; } //  id int
        public DateTime StartAt { get; set; } //  start_at timestamp
        public DateTime FinishAt { get; set; } //  finish_at timestamp
        public DateTime CreatedAt { get; set; } //  created_at timestamp
        public DateTime UpdatedAt { get; set; } //  updated_at timestamp

    }
}