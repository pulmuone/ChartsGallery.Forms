//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("ChartsGallery.Forms.Demo.Views.MainPage.xaml", "Demo/Views/MainPage.xaml", typeof(global::ChartsGallery.Forms.Views.MainPage))]

namespace ChartsGallery.Forms.Views {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Demo\\Views\\MainPage.xaml")]
    public partial class MainPage : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::ChartsGallery.Forms.ViewModels.MainViewModel viewModel;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::ChartsGallery.Forms.Demo.SvgIcon icon;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.ListView ItemsListView;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Grid header;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(MainPage));
            viewModel = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::ChartsGallery.Forms.ViewModels.MainViewModel>(this, "viewModel");
            icon = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::ChartsGallery.Forms.Demo.SvgIcon>(this, "icon");
            ItemsListView = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.ListView>(this, "ItemsListView");
            header = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Grid>(this, "header");
        }
    }
}