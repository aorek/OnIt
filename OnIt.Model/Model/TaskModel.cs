using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnIt.Model
{
   [Table("TASK")]
   public class TaskModel 
   {
      # region Attributes

      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int IdTask { get; set; }

      [StringLength(25)]
      public string Title { get; set; }

      [StringLength(100)]
      public string Desc { get; set; }

      [DataType(DataType.DateTime)]
      public DateTime CreationDate { get; set; }

      #endregion

   }
}
