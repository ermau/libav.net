namespace libavnet
{
	public delegate TResult Func<TResult, TArg1, TArg2, TArg3> (TArg1 arg1, TArg2 arg2, TArg3 arg3);
	public delegate TResult Func<TResult, TArg1, TArg2, TArg3, TArg4> (TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4);
}