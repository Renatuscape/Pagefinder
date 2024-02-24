import { Dispatch, SetStateAction } from "react";

type UserCardProps = {
  user: User | null;
  setUser: Dispatch<SetStateAction<User | null>>;
}

export function UserCard(props: UserCardProps) {
  return <>
    <div className="card" style={{ gridArea: 'user' }}>
      <h2>{props.user ? props.user.username : 'Log In'}</h2>

      {props.user ?
        <>
          <div className="button-container">
            <button>Edit</button>
            <button onClick={() => props.setUser(null)}>Log Out</button>
          </div>
        </>
        :
        <form style={{ marginTop: 15 }}>
          <input placeholder='username' type='text' />
          <input placeholder='password' type='password' />
          <button>Submit</button>
          <button>New User</button>
        </form>}
    </div>
  </>
}