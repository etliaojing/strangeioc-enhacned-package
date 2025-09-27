/*
 * Copyright 2013 ThirdMotion, Inc.
 *
 *	Licensed under the Apache License, Version 2.0 (the "License");
 *	you may not use this file except in compliance with the License.
 *	You may obtain a copy of the License at
 *
 *		http://www.apache.org/licenses/LICENSE-2.0
 *
 *		Unless required by applicable law or agreed to in writing, software
 *		distributed under the License is distributed on an "AS IS" BASIS,
 *		WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *		See the License for the specific language governing permissions and
 *		limitations under the License.
 */

/**
 * @class strange.extensions.mediation.impl.EventView
 * 
 * Injects a local event bus into this View. Intended
 * for local communication between the View and its
 * Mediator.
 * 
 * Caution: we recommend against injecting the context-wide
 * dispatcher into a View.
 */

using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;

namespace strange.extensions.mediation.impl
{
	public class EventView : View
	{
		[Inject]
		public IEventDispatcher Dispatcher{ get; set;}

		private Dictionary<object, EventCallback> _delayedEventsDictionary = new();
		
		/// <summary>
		/// Wait until IEventDispatcher is properly initialised, then attach the cached events
		/// </summary>
		/// <param name="evt"></param>
		/// <param name="callback"></param>
		public void AttachEventDelayed(object evt, EventCallback callback)
		{
			if (Dispatcher != null)
			{
				if (Dispatcher.HasListener(evt, callback))
				{
					return;
				}

				Dispatcher.AddListener(evt, callback);
				return;
			}
			
			_delayedEventsDictionary[evt] = callback;
		}

		protected override void Start()
		{
			base.Start();
			AttachAllEventsDelayed();
		}
		
		private void AttachAllEventsDelayed()
		{
			if (_delayedEventsDictionary == null) return;
			
			foreach (var pair in _delayedEventsDictionary)
			{
				Dispatcher.AddListener(pair.Key, pair.Value);
			}
			
			_delayedEventsDictionary.Clear();
		}
	}
}

