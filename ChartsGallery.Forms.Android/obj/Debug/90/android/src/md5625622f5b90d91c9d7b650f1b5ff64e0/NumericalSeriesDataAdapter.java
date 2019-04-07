package md5625622f5b90d91c9d7b650f1b5ff64e0;


public class NumericalSeriesDataAdapter
	extends md5625622f5b90d91c9d7b650f1b5ff64e0.XYSeriesDataAdapter
	implements
		mono.android.IGCUserPeer,
		com.devexpress.dxcharts.NumericSeriesData,
		com.devexpress.dxcharts.XYSeriesData
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getDataCount:()I:GetGetDataCountHandler:DevExpress.Xamarin.Android.Charts.INumericSeriesDataInvoker, DevExpress.Xamarin.Android.Charts\n" +
			"n_getArgument:(I)D:GetGetArgument_IHandler:DevExpress.Xamarin.Android.Charts.INumericSeriesDataInvoker, DevExpress.Xamarin.Android.Charts\n" +
			"n_getValue:(I)D:GetGetValue_IHandler:DevExpress.Xamarin.Android.Charts.INumericSeriesDataInvoker, DevExpress.Xamarin.Android.Charts\n" +
			"";
		mono.android.Runtime.register ("DevExpress.XamarinForms.Charts.Android.NumericalSeriesDataAdapter, DevExpress.XamarinForms.Charts.Android", NumericalSeriesDataAdapter.class, __md_methods);
	}


	public NumericalSeriesDataAdapter ()
	{
		super ();
		if (getClass () == NumericalSeriesDataAdapter.class)
			mono.android.TypeManager.Activate ("DevExpress.XamarinForms.Charts.Android.NumericalSeriesDataAdapter, DevExpress.XamarinForms.Charts.Android", "", this, new java.lang.Object[] {  });
	}


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
