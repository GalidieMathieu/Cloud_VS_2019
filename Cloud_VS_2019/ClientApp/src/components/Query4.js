import React, { Component } from 'react';

export class Query4 extends Component {
    static displayName = Query4.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

  componentDidMount() {
      this.populateQuery4Data();
  }

  static renderForecastsTable(forecasts) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>sexe</th>
            <th>nombre employes</th>
            <th>total employes</th>
            <th>pourcentage</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
              <tr key={forecast.iD}>
                  <td>{forecast.sexe}</td>
                  <td>{forecast.nb_emp.toString()}</td>
                  <td>{forecast.total_emp.toString()}</td>
                  <td>{forecast.percent.toString()}</td> 
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : Query4.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        <h1 id="tabelLabel" >Query 4</h1>
            <p>Proportion d'hommes / de femmes au sein de l'entreprise</p>
        {contents}
      </div>
    );
  }

  async populateQuery4Data() {
     const response = await fetch('Query4');
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
  }
}
