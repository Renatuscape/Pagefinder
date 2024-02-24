import { useState } from "react";
import { CreateStory } from "./CreateStory";

type EditorCardProps = {
    user: User | null;
    story: Story | null;
    collection: Collection | null;
}

export function EditorCard(props: EditorCardProps) {
    const [createStory, setCreateStory] = useState<Boolean>(false);
    const [createPage, setCreatePage] = useState<Boolean>(false);

    const [story, setStory] = useState<Story | null>(null);

    const clickCreateStory = ()=> {
        setCreateStory(true);
        setCreatePage(false);
    }

    const clickCancel = () => {
        setCreateStory(false);
        setCreatePage(false);
    }
    return <>
        <div className="card" style={{ gridArea: 'editor', backgroundColor: '#bfe4e6' }}>
            {props.user ?
                <>
                    <h2>Editor</h2>
                    {createStory && <>
                        <CreateStory setCreateStory={() => setCreatePage} userID={props.user?.id} />
                    </>}
                </>
                :
                <div className="card"><h2>Log in to begin creating!</h2></div>
            }

            <div className="button-container">
                <button onClick={clickCreateStory}>Create Story</button><button>Create Page</button><button onClick={clickCancel}>Cancel</button>
            </div>
        </div>
    </>
}