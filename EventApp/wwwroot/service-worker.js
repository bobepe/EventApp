const CACHE_NAME = "eventapp-cache-v1";
const urlsToCache = [
    "/",
    "/style.css",
    "/manifest.json",
    "/images/icon-192.png",
    "/images/icon-512.png"
];

/* Spusteni service workera a kesovani veskereho obsahu */
self.addEventListener("install", event => {
    event.waitUntil(
        caches.open(CACHE_NAME)
            .then(cache => cache.addAll(urlsToCache))
    );
});

/* Zobrazeni kesovaneho obsahu v offline modu */
/*self.addEventListener("fetch", event => {
    event.respondWith(
        caches.match(event.request)
            .then(response => {
                return response || fetch(event.request);
            })
    );
});*/
/*self.addEventListener("fetch", event => {
    event.respondWith(
        fetch(event.request).catch(() => caches.match("/"))
    );
});*/
self.addEventListener("fetch", event => {
    event.respondWith(
        fetch(event.request)
            .then(response => {
                return caches.open("eventapp-cache-v1")
                    .then(cache => {
                        cache.put(event.request, response.clone());
                        return response;
                    });
            })
            .catch(() => caches.match(event.request)
                .then(response => response || caches.match("/"))
            )
    );
});