using System;
using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace BABY_AVALONIA_MVVM.Views;

public partial class PooPooView : UserControl
{
    private Carousel _carousel;
    private Button _left;
    private Button _right;
  
    
    public PooPooView()
    {
        InitializeComponent();
        _carousel = this.Get<Carousel>("carousel");
        _left = this.Get<Button>("left");
        _right = this.Get<Button>("right");
  
        _left.Click += (s, e) => _carousel.Previous();
        _right.Click += (s, e) => _carousel.Next();
      
        _carousel.PageTransition = new CrossFade(TimeSpan.FromSeconds(0.25));
    }



}