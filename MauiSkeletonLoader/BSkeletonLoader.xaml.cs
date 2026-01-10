namespace SkeletonLoader;

public partial class BSkeletonLoader : Border
{
    public static readonly BindableProperty SpeedProperty =
        BindableProperty.Create(nameof(Speed), typeof(double), typeof(BSkeletonLoader), 1d);
    
    public static readonly BindableProperty DelaySecondProperty =
        BindableProperty.Create(nameof(DelaySecond), typeof(double), typeof(BSkeletonLoader), 1d);
    
    public new static readonly BindableProperty BackgroundColorProperty =
        BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(BSkeletonLoader), new Color(60,60,60));
    
    public static readonly BindableProperty WaveColorProperty =
        BindableProperty.Create(nameof(WaveColor), typeof(Color), typeof(BSkeletonLoader), new Color(70, 70, 70));

    public double Speed
    {
        get => (double)GetValue(SpeedProperty);
        set => SetValue(SpeedProperty, value);
    }
    
    public double DelaySecond
    {
        get => (double)GetValue(DelaySecondProperty);
        set => SetValue(DelaySecondProperty, value);
    }
    
    public new Color BackgroundColor
    {
        get => (Color)GetValue(BackgroundColorProperty);
        set => SetValue(BackgroundColorProperty, value);
    }
    
    public Color WaveColor
    {
        get => (Color)GetValue(WaveColorProperty);
        set => SetValue(WaveColorProperty, value);
    }
    
    private CancellationTokenSource? _cts;
    
    public BSkeletonLoader()
    {
        InitializeComponent();
        
        Loaded += OnLoaded;
        Unloaded += OnUnloaded;
    }
    
    private async void OnLoaded(object? sender, EventArgs e)
    {
        try
        {
            _cts = new CancellationTokenSource();
            await SkeletonAnimationAsync();
        }
        catch (Exception)
        {
            return;
        }
    }

    private void OnUnloaded(object? sender, EventArgs e)
    {
        _cts?.Cancel();
        this.AbortAnimation("SkeletonAnimation");
        
        Loaded -= OnLoaded;
        Unloaded -= OnUnloaded;
    }

    private Task SkeletonAnimationAsync()
    {
        if (_cts is null)
        {
            Console.Error.WriteLine("SkeletonLoader Error : CancellationTokenSource was Null, Report to Developer!");
            return Task.CompletedTask;
        }
        
        if(_cts.IsCancellationRequested) return Task.CompletedTask;
        
        var animation = new Animation(d =>
        {
            var gradient1 = (float)(d - 0.3);
            var gradient2 = (float)d;
            var gradient3 = (float)(d + 0.3);

            GradientStop1.Offset = gradient1;
            GradientStop2.Offset = gradient2;
            GradientStop3.Offset = gradient3;
        }, 0 ,2);

        animation.Commit(
            this,
            "SkeletonAnimation",
            16,
            (uint)(1000 * Speed),
            Easing.Linear,
            finished: async void (_, isCanceled) =>
            {
                try
                {
                    if(isCanceled || _cts.IsCancellationRequested) return;
                    await Task.Delay((int)(1000 * DelaySecond), _cts.Token);
                    await SkeletonAnimationAsync();
                }
                catch (Exception)
                {
                    await _cts?.CancelAsync()!;
                    return;
                }
            },
            repeat: () => false);

        return Task.CompletedTask;
    }
}