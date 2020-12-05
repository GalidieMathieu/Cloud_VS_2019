import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Application pour le Cloud</h1>
        <p>cette application a ete developper par :</p>
        <ul>
            <li> Galidie Mathieu </li>
            <li>Goasduff Baptiste </li>
            <li> Gerard Bastien</li>
            <li> Fropo Thomas</li>
        </ul>
        </div>
    );
  }
}
