Comments
=========

Design decisions
-----------------

* I've deferred the decision on storage/persistence. Currently a simple 
  Store<> class is sufficient.
* Optimistic concurrency is good enough for this simple use case, avoiding 
  transactions that make it harder to scale out.
* The application protocol for borrowing and returning books is simple and 
  working, but it does not provide any traceability or possibility to have 
  multiple copies of a book.
* Since we're not (yet) I/O-bound, I chose to go syncrounous. When fitting 
  another persistance engine, I'd rather have async controllers.
* I am using [API Blueprint](http://apiblueprint.org/) for documentation. 
  Then [apiary.io](http://apiary.io/) provides nice documentation with 
  examples and mocking.

Additions/improvements
-----------------------

If I'd continue, I would consider the following additions and adjustments 
to the API:

* Extended protocol for borrowing books, representing each loan by it's 
  own resource that can be updated/amended when returning the book.
* All endpoints need appropriate cache headers.
* Limit amount of data through paging, preferably paging through LinkHeaders 
  ([RFC5988](http://tools.ietf.org/html/rfc5988#page-6))
* Add filtering and sorting through querystring parameters.
* API versioning. Put major version number in the URL since it makes the API 
  explorable with a browser.
* Logging and tracing.
* Refactor tests to be more context driven (BDD-ish).
* Authentication, at least an API-key for identification. 
* SSL everything. Goes for any public API. Disable all non-SSL access, no 
  redirects.
* Sensible handling of 500 errors.* Add links for driving HATEOAS, relieving 
  clients 
  from depend on deep links and documentation.
* Settling on same return for all controller actions: either 
  HttpResponseMessage or ActionResult.
* Investigate if another technology would fit even better.
