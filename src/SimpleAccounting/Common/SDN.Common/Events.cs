﻿using Microsoft.Practices.Prism.Events;

namespace SDN.Common
{
    public class TabVisibilityEvent : CompositePresentationEvent<bool> { }
    public class SubTabVisibilityEvent : CompositePresentationEvent<bool> { }
    public class TitleChangedEvent : CompositePresentationEvent<string> { }
    public class CompanynameChangedEvent : CompositePresentationEvent<string> { }
}
