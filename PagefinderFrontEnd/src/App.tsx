import { useState } from 'react'
import './App.css'
import { UserCard } from './components/UserCard'
import { LibraryCard } from './components/LibraryCard'
import { EditorCard } from './components/EditorCard'
import { ReaderCard } from './components/ReaderCard'

function App() {
  // const [user, setUser] = useState<User | null>(null)
  const [user, setUser] = useState<User | null>({ id: 4, username: 'TestUsername', email: '', password: '' })
  const [readStory, setReadStory] = useState<Story | null>(null);
  
  return (
    <>
      <h1>Pagefinder</h1>
      <div className="card-container">
        <div className="card" style={{ gridArea: 'banner', display: 'flex', justifyContent: 'center', alignItems: 'center', height: 35, backgroundColor: '#bfe4e6' }}>
          {user ? 'Welcome back!' : 'Create a user or log in to work on your stories.'}
        </div>
        <UserCard user={user} setUser={setUser} />
        <LibraryCard user={user} />

        <EditorCard user={user} story={null} collection={null}/>
        <ReaderCard story={readStory} />
      </div>
      <p className="read-the-docs">
        A storycrafting tool by Renatuscape
      </p>
    </>
  )
}

export default App
