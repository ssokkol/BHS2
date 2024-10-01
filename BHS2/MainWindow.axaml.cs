using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Interactivity;
using BHS2.Controllers;
using BHS2.Models;

namespace BHS2
{
    public partial class MainWindow : Window
    {
        private readonly ShapeController _controller;
        private Rectangle _rectangle;
        private TextBlock _rectText;
        private Ellipse _circle;
        private TextBlock _circleText;

        public MainWindow()
        {
            InitializeComponent();
            _controller = new ShapeController();

            _rectangle = new Rectangle();
            ShapeCanvas.Children.Add(_rectangle);

            _rectText = new TextBlock
            {
                HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center
            };
            ShapeCanvas.Children.Add(_rectText);

            _circle = new Ellipse();
            ShapeCanvas.Children.Add(_circle);

            _circleText = new TextBlock
            {
                HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center
            };
            ShapeCanvas.Children.Add(_circleText);

            ShapeSelector.SelectedIndex = 0; 
            UpdateShapes();
        }

        private void OnShapeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateShapes();
        }

        private void UpdateShapes()
        {
            if (ShapeSelector.SelectedIndex == 0)
            {
                _controller.UpdateRectangle(_rectangle, _rectText);
                _rectText.SetValue(Canvas.LeftProperty, _rectangle.Width / 2 - _rectText.Bounds.Width / 2 + _controller.GetRectangleModel().TextPosX);
                _rectText.SetValue(Canvas.TopProperty, _rectangle.Height / 2 - _rectText.Bounds.Height / 2 + _controller.GetRectangleModel().TextPosY);
                _rectangle.IsVisible = true;
                _rectText.IsVisible = true;
                _circle.IsVisible = false;
                _circleText.IsVisible = false;
            }
            else if (ShapeSelector.SelectedIndex == 1) 
            {
                _controller.UpdateCircle(_circle, _circleText);
                _circleText.SetValue(Canvas.LeftProperty, _circle.Width / 2 - _circleText.Bounds.Width / 2 + _controller.GetCircleModel().TextPosX);
                _circleText.SetValue(Canvas.TopProperty, _circle.Height / 2 - _circleText.Bounds.Height / 2 + _controller.GetCircleModel().TextPosY);
                _rectangle.IsVisible = false;
                _rectText.IsVisible = false;
                _circle.IsVisible = true;
                _circleText.IsVisible = true;
            }
        }

        private void OnUpdateClick(object sender, RoutedEventArgs e)
        {
            if (ShapeSelector.SelectedIndex == 0) 
            {
                var rectModel = _controller.GetRectangleModel();
                rectModel.Width = RectWidthSlider.Value;
                rectModel.Height = RectHeightSlider.Value;
                rectModel.Rotation = RectRotationSlider.Value;
                rectModel.ShapeColor = RectColorTextBox.Text;
                rectModel.Text = ShapeTextTextBox.Text;
                rectModel.TextColor = TextColorTextBox.Text;
                rectModel.TextPosX = TextPosXSlider.Value - rectModel.Width / 2;
                rectModel.TextPosY = TextPosYSlider.Value - rectModel.Height / 2;
            }
            else if (ShapeSelector.SelectedIndex == 1)
            {
                var circleModel = _controller.GetCircleModel();
                circleModel.Radius = CircleRadiusSlider.Value;
                circleModel.HorizontalScale = CircleHScaleSlider.Value;
                circleModel.VerticalScale = CircleVScaleSlider.Value;
                circleModel.ShapeColor = CircleColorTextBox.Text;
                circleModel.Text = ShapeTextTextBox.Text;
                circleModel.TextColor = TextColorTextBox.Text;
                circleModel.TextPosX = TextPosXSlider.Value - circleModel.Radius;
                circleModel.TextPosY = TextPosYSlider.Value - circleModel.Radius;
            }

            UpdateShapes();
        }
    }
}