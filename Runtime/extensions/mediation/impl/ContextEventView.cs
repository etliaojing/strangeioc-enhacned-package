using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;

namespace strange.extensions.mediation.impl
{
	public class ContextEventView : View
	{
		[Inject(ContextKeys.CONTEXT_DISPATCHER)]
		public IEventDispatcher Dispatcher{ get; set; }
	}
}