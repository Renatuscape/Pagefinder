type ReaderCardProps = {
    story: Story | null;
}

export function ReaderCard(props: ReaderCardProps){
    return <>
    <div className="card" style={{ gridArea: 'reader' }}>
          <h2>Story Preview</h2>
          <p>
            <img src='' style={{ height: 100, width: 100 }} /><br />
            Content printed here<br />
            <button>Edit</button><button>Delete</button><button>open/close</button>
          </p>
        </div>
        </>
}