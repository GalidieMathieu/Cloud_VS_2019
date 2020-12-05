import React, { Component } from 'react';

export class Query7 extends Component {
  static displayName = Query7.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

  componentDidMount() {
      this.populateQuery7Data();
  }

  static renderForecastsTable(forecasts) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>num dept</th>
            <th>moyenne age</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
              <tr key={forecast.iD}>
                  <td>{forecast.id}</td>
                  <td>{forecast.moy_age.toString()}</td> 
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Query7.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        <h1 id="tabelLabel" >Query7</h1>
            <p>Moyenne d'age d'entree dans un departement par poste.</p>
        {contents}
      </div>
    );
  }

  async populateQuery7Data() {
    const response = await fetch('Query7');
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
  }
}
