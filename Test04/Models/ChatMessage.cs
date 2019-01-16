using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Test04.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public String ConnectionId { get; set; }
        [Required,StringLength(20,MinimumLength =2)]
        public String UserName { get; set; }
        [Required,DataType(DataType.MultilineText)]
        public String Message { get; set; }
        public DateTime? SentDate { get; set; }//name

    }//class
}//namespace