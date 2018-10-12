using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WebApi.Repository;

namespace WebApi.Models.Bdd
{
    [MetadataType(typeof(ComposantMetaData))]
    public partial class Composant
    {

    }
    public class ComposantMetaData
    {
        public int idFormulaire { get; set; }
        public int idQuestion { get; set; }
        public int idTypeReponse { get; set; }
        public int id { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Formulaire Formulaire { get; set; }
        public virtual Question Question { get; set; }
        public virtual TypeReponse TypeReponse { get; set; }

    }
}