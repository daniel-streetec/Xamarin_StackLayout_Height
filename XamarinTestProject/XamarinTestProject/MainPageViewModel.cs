using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace XamarinTestProject
{
    [ObservableObject]
    partial class MainPageViewModel
    {
        private Random rnd = new Random(256);
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ";
        public ObservableCollection<ItemContainer> ItemContainers { get; private set; } = new ObservableCollection<ItemContainer>();

        [ObservableProperty]
        private bool _multiline = false;

        [RelayCommand]
        public void Add()
        {
            var newContainer = new ItemContainer($"{ItemContainers.Count + 1}");
            int itemCount = rnd.Next(3, 10);
            for(int i=0; i<itemCount; i++)
            {
                int itemLength = rnd.Next(5, Multiline ? 100 : 20);
                newContainer.Items.Add(
                    new string(
                        Enumerable.Repeat(chars, itemLength)
                        .Select(s => s[rnd.Next(s.Length)]).ToArray()));
            }
            ItemContainers.Add(newContainer);
        }

        [RelayCommand]
        public void Clear()
        {
            ItemContainers.Clear();
        }
    }

    [ObservableObject]
    partial class ItemContainer
    {
        public ObservableCollection<string> Items { get; private set; } = new ObservableCollection<string>();

        [ObservableProperty]
        private string _title;

        public ItemContainer(string title) { _title = title; }
    }
}
