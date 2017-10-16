using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static OnIt.Helper.Enums;

namespace OnIt.Model
{
   [Table("TASK")]
   public class TaskModel 
   {
      # region Attributes

      [Key]
      [Index]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int IdTask { get; set; }

      [Required]
      [StringLength(25)]
      public string Title { get; set; }

      [StringLength(100)]
      public string Description { get; set; }

      public PriorityTypes Priority { get; set; }

      [DataType(DataType.DateTime)]
      public DateTime CreationDate { get; set; }

      [DataType(DataType.DateTime)]
      public DateTime DueDate { get; set; }

      #endregion
   }
}
