type EditorCardProps = {
    user : User | null;
    story : Story | null;
    collection : Collection | null;
}

export function EditorCard(props: EditorCardProps){


return <>
    <div className="card" style={{ gridArea: 'editor' }}>
    <h2>Editor</h2>
    <div className="button-container">
    <button>New Story</button><button>New Collection</button><button>Save Changes</button><button>Cancel</button>
      </div>
  </div>
  </>
}