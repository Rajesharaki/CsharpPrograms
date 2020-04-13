using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
    /// <summary>
    /// this class represents the model for labels operation
    /// </summary>
    public class LabelsModel
    {
        [Key,]
        public int Id { get; set; }
        [Required]
        public int LBNumber { get; set; }
        [Required]
        public string Label { get; set; }
    }
}
