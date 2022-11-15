using System;
using Shared.DTOs;
using Xamarin.Forms;

namespace ASCamarerosApp.DataTemplates
{
    public class DataTemplateSelectorMesa :DataTemplateSelector
    {
        public DataTemplate MesaOcupada { get; set; }
        public DataTemplate MesaLibre { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((MesaDTO)item).Ordenes.Count > 0 ? MesaOcupada : MesaLibre;
        }
    }
}
