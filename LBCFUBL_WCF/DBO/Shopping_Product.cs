//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LBCFUBL_WCF.DBO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shopping_Product
    {
        public System.Guid id_shopping { get; set; }
        public System.Guid id_product { get; set; }
        public int number { get; set; }
        public int id { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Shopping Shopping { get; set; }
    }
}
