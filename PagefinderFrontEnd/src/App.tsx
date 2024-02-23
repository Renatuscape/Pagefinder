import { useState } from 'react'
import './App.css'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <h1>Pagefinder</h1>
      <div className="card-container">
      <div className="card" style={{gridArea: 'user'}}>
        <h2>User</h2>
        <p>
          Login form
        </p>
        <p>
          Information about the active user
        </p>
        <form style={{display: 'flex', gap: 10}}>
          <input placeholder='username' type='text'/>
          <input placeholder='password' type='password'/>
          <button>Submit</button>          
        </form>
      </div>
      <div className="card" style={{gridArea: 'portfolio'}}>
        <h2>Portfolio</h2>
        <button>New Collection</button>
        <p>
          The user's collections. Collapsible. Each collection has an edit button and a new story button.<br/>
          <button>open/close</button>
        </p>
      </div>
      <div className="card" style={{gridArea: 'collectionManager'}}>
        <h2>Collection Manager</h2>
        <p>
          <img src='' style={{height: 100, width: 100}}/><br/>
          Collection description<br/>
          <button>Edit</button><button>Delete</button><button>open/close</button>
        </p>
      </div>
      <div className="card" style={{gridArea: 'storyManager'}}>
        <h2>Story Manager</h2>
        <p>
          <img src='' style={{height: 100, width: 100}}/><br/>
          Story description<br/>
          <button>Edit</button><button>Delete</button><button>open/close</button>
        </p>
      </div>
      <div className="card" style={{gridArea: 'reader'}}>
        <h2>Story Preview</h2>
        <p>
          <img src='' style={{height: 100, width: 100}}/><br/>
          Content printed here<br/>
          <button>Edit</button><button>Delete</button><button>open/close</button>
        </p>
      </div>
      </div>
      <p className="read-the-docs">
        A storycrafting tool by Renatuscape
      </p>
    </>
  )
}

export default App
