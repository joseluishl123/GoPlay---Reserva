﻿using PlacesApp.ViewModels.Equipo;
using System;
using WSGOPLAY.Models.red;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlacesApp.Views.Equipo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewMiequipo : ContentPage
    {
        MiEquipoViewModel contexto => ((MiEquipoViewModel)BindingContext);
        public ViewMiequipo()
        {
            InitializeComponent();
            if (contexto.Groups != null && contexto.Groups.Count > 0)
                TxtEquipo.SelectedIndex = 0;


        }

        protected override void OnAppearing()
        {
            if (contexto.Groups != null && contexto.Groups.Count > 0)
                TxtEquipo.SelectedIndex = 0;
            //DisplayAlert("", contexto.Group..ToString(), "OK");
            
            //base.OnAppearing();
        }

        private void TxtEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            contexto.Ocupado = true;
            var retu = TxtEquipo.SelectedItem as WoGroupMembers;
            contexto.Group = new WoGroups
            {
                GroupTitle = retu.Grupo.GroupTitle,
                Avatar = retu.Grupo.Avatar,
                About = retu.Grupo.About,
                Id = retu.Id,
                Cover = retu.Grupo.Cover,
            };
            contexto.Ocupado = false;
            //DisplayAlert("", TxtEquipo.SelectedItem.ToString(), "OK");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("", contexto.Groups.Count.ToString(), "OK");
            Lista.ItemsSource = contexto.Groups;
        }
    }
}