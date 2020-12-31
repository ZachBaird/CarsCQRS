using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;

namespace Data
{
    internal static class Database
    {
        // Use Lazy<IDocumentStore> to initialize the document store lazily. 
        // This ensures that it is created only once - when first accessing the public `Store` property.
        private static readonly Lazy<IDocumentStore> instance = new Lazy<IDocumentStore>(CreateStore);

        public static IDocumentStore Instance => instance.Value;

        public static IAsyncDocumentSession AsyncSession => Instance.OpenAsyncSession();

        private static IDocumentStore CreateStore()
        {
            IDocumentStore store = new DocumentStore()
            {
                Urls = new[] { "http://127.0.0.1:8080" },
                Database = "FirstDemo"

            }.Initialize();

            return store;
        }
    }
}
