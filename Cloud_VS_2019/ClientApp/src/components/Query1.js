import React, { Component } from 'react';

export class Query1 extends Component {
  static displayName = Query1.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

  componentDidMount() {
      this.populateQuery1Data();
  }

  static renderForecastsTable(forecasts) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>first name</th>
            <th>last name</th>
            <th>date debut post</th>
            <th>duree travail poste</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
              <tr key={forecast.Id}>
                  <td>{forecast.first_name}</td>
                  <td>{forecast.last_name}</td>
                  <td>{forecast.entre_post}</td>
                  <td>{forecast.post.toString()}</td>    
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Query1.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        <h1 id="tabelLabel" >Query 1</h1>
            <p>Trouve depuis combien de temps un(e) employe(e) travaille sur son poste actuel.</p>
        {contents}
      </div>
    );
  }

  async populateQuery1Data() {
    const response = await fetch('Query1');
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
  }
}
