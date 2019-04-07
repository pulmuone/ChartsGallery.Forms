package md5625622f5b90d91c9d7b650f1b5ff64e0;


public class WeightedNumericSeriesDataAdapter
	extends md5625622f5b90d91c9d7b650f1b5ff64e0.NumericalSeriesDataAdapter
	implements
		mono.android.IGCUserPeer,
		com.devexpress.dxcharts.WeightedNumericSeriesData,
		com.devexpress.dxcharts.NumericSeriesData,
		com.devexpress.dxcharts.XYSeriesData
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getWeight:(I)D:GetGetWeight_IHandler:DevExpress.Xamarin.Android.Charts.IWeightedNumericSeriesDataInvoker, DevExpress.Xamarin.Android.Charts\n" +
			"n_getDataCount:()I:GetGetDataCountHandler:DevExpress.Xamarin.Android.Charts.INumericSeriesDataInvoker, DevExpress.Xamarin.Android.Charts\n" +
			"n_getArgument:(I)D:GetGetArgument_IHandler:DevExpress.Xamarin.Android.Charts.INumericSeriesDataInvoker, DevExpress.Xamarin.Android.Charts\n" +
			"n_getValue:(I)D:GetGetValue_IHandler:DevExpress.Xamarin.Android.Charts.INumericSeriesDataInvoker, DevExpress.Xamarin.Android.Charts\n" +
			"";
		mono.android.Runtime.register ("DevExpress.XamarinForms.Charts.Android.WeightedNumericSeriesDataAdapter, DevExpress.XamarinForms.Charts.Android", WeightedNumericSeriesDataAdapter.class, __md_methods);
	}


	public WeightedNumericSeriesDataAdapter ()
	{
		super ();
		if (getClass () == WeightedNumericSeriesDataAdapter.class)
			mono.android.TypeManager.Activate ("DevExpress.XamarinForms.Charts.Android.WeightedNumericSeriesDataAdapter, DevExpress.XamarinForms.Charts.Android", "", this, new java.lang.Object[] {  });
	}


	public double getWeight (int p0)
	{
		return n_getWeight (p0);
	}

	private native double n_getWeight (int p0);


	public int getDataCount ()
	{
		return n_getDataCount ();
	}

	private native int n_getDataCount ();


	public double getArgument (int p0)
	{
		return n_getArgument (p0);
	}

	private native double n_getArgument (int p0);


	public double getValue (int p0)
	{
		return n_getValue (p0);
	}

	private native double n_getValue (int p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
