//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DbFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class CourseSection
    {
        public int SectionID { get; set; }
        public int CourseID { get; set; }
        public string Title { get; set; }
    
        public virtual Course Cours { get; set; }
    }
}
