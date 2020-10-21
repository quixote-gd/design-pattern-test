// Base class for any access control that will need processing.
public abstract class AbstractAccessControlProcessorProvider
{
    public void someGlobalToDo(AccessControl domain) 
    {
        // do something
    }

    public abstract loadAdditionalData(AccessControl domain, User user);
    public abstract runSecurity(AccessControl domain, User user);
    public abstract runRules(AccessControl domain, User user);
    public abstract getAccessControlTypeID();
}


// Called from the mediatr pipeline.
// Will process any AbstractAccessControlProcessorProvider type.
public AccessControlProcessorImpl : AccessControlProcessor 
{
	private IDict<Integer, AccessControlProvider> accessControlProcessProviders = new Dict<Integer,  AccessControlProcessProvider>();

    public AccessControlProcessorImpl 
    {
        foreach (var processorProvider in typeof(AbstractAccessControlProcessorProvider).Assembly.GetTypes())    
        {    
            if (typeof(AbstractAccessControlProcessorProvider).IsAssignableFrom(processorProvider) && !processorProvider.IsInterface)    
            {    
                var processorProviderInstance = (IProduct)Activator.CreateInstance(processor);    
                accessControlProcessProviders.Add(processorProviderInstance.GetAccessControlTypeID(), processorProviderInstance);   
            }    
        }

    }

	public AccessControl getAccessControl(Integer id, Integer accessControlTypeID, User user) 
	{
		AccessControlProcessorProvider p = AccessControlProcessProviders.get(accessControlTypeID);
        AccessControl domain = db.GetAccessControl(id);
        p.runSecurity(domain, user);
        p.loadAdditionalData(domain, user);
		return domain;
	}

	public void processAccessControl(AccessControl domain, User user)
	{
		AccessControlProcessorProvider p = AccessControlProcessProviders.get(domain.AccessControlTypeID);
        
        p.someGlobalToDo(domain)

        p.loadAdditionalData(domain, user);
        p.runSecurity(domain, user);
        p.runRules(domain, user);
        p.save(domain, user);
	}

    public AccessControl createBlankAccessControl(AccessControl domain, User user)
	{
		AccessControlProcessorProvider p = AccessControlProcessProviders.get(domain.AccessControlTypeID);
        AccessControl domain = new AccessControl();
        p.loadAdditionalData(domain);
        return domain;
	}
}

public StickerAccessControlProcessor : AbstractAccessControlProcessorProvider
{

	public Integer GetAccessControlTypeID() 
	{	
		return AccessControlConstants.STICKER.ID;
	}
	
    public void loadSpecificAccessControlInformation(AccessControl domain, User user) 
	{
		// get any data via repository for the domain?
	}

	public void runSecurity(AccessControl domain, User user) 
	{
		// maybe some security on fields?
	}

	public void runRules(AccessControl domain, User user) 
	{
		// fluent validation?
	}
}


public HangTagAccessControlProcessor : AbstractAccessControlProcessorProvider
{

	public Integer GetAccessControlTypeID() 
	{	
		return AccessControlConstants.HANGTAG.ID;
	}
	
	public void loadSpecificAccessControlInformation(AccessControl domain, User user) 
	{
		// get any data via repository for the domain?
	}

	public void runSecurity(AccessControl domain, User user) 
	{
		// maybe some security on fields?
	}

	public void runRules(AccessControl domain, User user) 
	{
		// fluent validation?
	}
}


// Get call from mediatr

public GetAccessControlQuery : IRequest<AccessControl, AppResponse>() 
{	
	AccessControl AccessControl {get; set;}
}

public GetAccessControlQueryHandler : IRequest<AccessControl, AppResponse>() 
{	
	
	AccessControlProcessor processor;

	public AccessControlQueryHandler (AccessControlProcessor processor)
	{
		this.processor = processor;
	}

    public void Handle() 
    {
        processor.getAccessControl(domain.AccessControlID(), user);
    }
}


// Create call from mediatr
public NewAccessControlQuery : IRequest<AccessControl, AppResponse>() 
{	
	AccessControl AccessControl {get; set;}
}


public NewAccessControlQueryHandler : IRequest<AccessControl, AppResponse>() 
{	
	
	AccessControlProcessor processor;

	public AccessControlQueryHandler (AccessControlProcessor processor)
	{
		this.processor = processor;
	}

    public void Handle() 
    {
        processor.createBlankAccessControl(domain.AccessControlID(), user);
    }
}


// Update call from mediatr
public UpdateAccessControlCommand : IRequest<AccessControl, AppResponse>() 
{
	AccessControl AccessControl {get; set;}
}

public UpdateAccessControlCommandHandler : IRequest<AccessControl, AppResponse>() 
{
	AccessControlProcessor processor;

	public AccessControlCommand (AccessControlProcessor processor)
	{
		this.processor = processor;
	}
	
    public void Handle() 
    {
        processor.processAccessControl(domain, user);
    }
}