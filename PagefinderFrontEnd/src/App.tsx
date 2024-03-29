import { useEffect, useState } from 'react'
import './App.css'
import { UserCard } from './components/UserCard'
import { LibraryCard } from './components/LibraryCard'
import { EditorCard } from './components/EditorCard'
import { ReaderCard } from './components/ReaderCard'

async function fetchUserAsync(id: number | undefined): Promise<User> {
  const response = await fetch(`https://localhost:7177/User/${id}/library`);

  try {
      const resObject = await response.json();

      console.log(resObject);

      return resObject;
  }
  catch (error) {
      console.log(error);
      return { id: -1, username: 'BadResponse', email: '', password: '' };
  }
}

function App() {
  // const [user, setUser] = useState<User | null>(null)
  const [user, setUser] = useState<User | null>({ id: -1, username: 'Default', email: '', password: '', collections: [] })
  const [readStory, setReadStory] = useState<Story | null>(null);
  
  useEffect(() => {
    fetchUserAsync(4).then(user => setUser(user));
}, [])

    // Function to update the user object with the edited collection
    const updateCollectionInUser = (updatedCollection: Collection) => {
      setUser(prevUser => {
          if (prevUser) {
              const updatedCollections = prevUser.collections?.map(collection =>
                  collection.id === updatedCollection.id ? updatedCollection : collection
              );
              return { ...prevUser, collections: updatedCollections };
          }
          return prevUser;
      });
  };

  return (
    <>
      <h1>Pagefinder</h1>
      <div className="card-container">
        <div className="card" style={{ gridArea: 'banner', display: 'flex', justifyContent: 'center', alignItems: 'center', height: 35, backgroundColor: '#bfe4e6' }}>
          {user ? 'Welcome back!' : 'Create a user or log in to work on your stories.'}
        </div>
        <UserCard user={user} setUser={setUser} />
        <LibraryCard user={user} />

        <EditorCard user={user} story={null} collection={null} updateCollectionInUser={updateCollectionInUser}/>
        <ReaderCard story={readStory} />
      </div>
      <p className="read-the-docs">
        A storycrafting tool by Renatuscape
      </p>
    </>
  )
}

export default App
