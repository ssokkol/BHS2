using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Controls;
using BHS2.Models;

namespace BHS2.Controllers;

public class ShapeController
{
    private readonly ShapeModel _rectangleModel;
    private readonly ShapeModel _circleModel;

    public ShapeController()
    {
        _rectangleModel = new ShapeModel { Width = 100, Height = 100, ShapeColor = "Blue" };
        _circleModel = new ShapeModel { Radius = 50, ShapeColor = "Red" };
    }

    public ShapeModel GetRectangleModel() => _rectangleModel;
    public ShapeModel GetCircleModel() => _circleModel;

    public void UpdateRectangle(Rectangle rectangle, TextBlock textBlock)
    {
        rectangle.Width = _rectangleModel.Width;
        rectangle.Height = _rectangleModel.Height;
        rectangle.RenderTransform = new RotateTransform(_rectangleModel.Rotation);

        if (!string.IsNullOrEmpty(_rectangleModel.ShapeColor))
        {
            rectangle.Fill = new SolidColorBrush(Color.Parse(_rectangleModel.ShapeColor));
        }

        textBlock.Text = _rectangleModel.Text;

        if (!string.IsNullOrEmpty(_rectangleModel.TextColor))
        {
            textBlock.Foreground = new SolidColorBrush(Color.Parse(_rectangleModel.TextColor));
        }

        Canvas.SetLeft(textBlock, _rectangleModel.TextPosX);
        Canvas.SetTop(textBlock, _rectangleModel.TextPosY);
    }

    public void UpdateCircle(Ellipse circle, TextBlock textBlock)
    {
        circle.Width = _circleModel.Radius * 2;
        circle.Height = _circleModel.Radius * 2;
        circle.RenderTransform = new ScaleTransform(_circleModel.HorizontalScale, _circleModel.VerticalScale);

        if (!string.IsNullOrEmpty(_circleModel.ShapeColor))
        {
            circle.Fill = new SolidColorBrush(Color.Parse(_circleModel.ShapeColor));
        }

        textBlock.Text = _circleModel.Text;

        if (!string.IsNullOrEmpty(_circleModel.TextColor))
        {
            textBlock.Foreground = new SolidColorBrush(Color.Parse(_circleModel.TextColor));
        }

        Canvas.SetLeft(textBlock, _circleModel.TextPosX);
        Canvas.SetTop(textBlock, _circleModel.TextPosY);
    }
}